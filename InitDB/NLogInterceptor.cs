using InitDB.Model;
using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDB
{
    public class NLogInterceptor : IDbCommandInterceptor
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private static readonly ConcurrentDictionary<DbCommand, DateTime> _mStartTime = new ConcurrentDictionary<DbCommand, DateTime>();

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            //LogIfError(command, interceptionContext);
            Log(command, interceptionContext);
            Executed(command, interceptionContext);
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            //LogIfNonAsync(command, interceptionContext);
            OnStart(command);
            Executing(command, interceptionContext);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            //LogIfError(command, interceptionContext);
            Log(command, interceptionContext);
            Executed(command, interceptionContext);
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            //LogIfNonAsync(command, interceptionContext);
            OnStart(command);
            Executing(command, interceptionContext);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            //LogIfError(command, interceptionContext);
            Log(command, interceptionContext);
            Executed(command, interceptionContext);
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            //LogIfNonAsync(command, interceptionContext);
            OnStart(command);
            Executing(command, interceptionContext);
        }

        private void LogIfNonAsync<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("command used:");
            sb.AppendLine(command.CommandText.Replace(Environment.NewLine, ""));
            foreach (DbParameter param in command.Parameters)
            {
                sb.AppendLine($"set {param.ParameterName} = {param.Value}");
            }
            _logger.Debug(sb.ToString());
            
        }

        private void LogIfError<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            if(interceptionContext.Exception != null)
            {
                _logger.Error($"Command {command.CommandText} faild with exception {interceptionContext.Exception}");
            }
        }

        #region 计算sql执行耗时方法一
        private void OnStart(DbCommand command)
        {
            _mStartTime.TryAdd(command, DateTime.Now);
        }

        private void Log<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            DateTime startTime;
            TimeSpan duration;

            _mStartTime.TryRemove(command, out startTime);
            if (startTime != default(DateTime))
            {
                duration = DateTime.Now - startTime;
            }
            else
            {
                duration = TimeSpan.Zero;
            }
            //int requestId = -1;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("command used:");
            sb.AppendLine(command.CommandText.Replace(Environment.NewLine, ""));

            StringBuilder parameters = new StringBuilder();
            foreach (DbParameter param in command.Parameters)
            {
                parameters.AppendLine($"{param.ParameterName} {param.DbType} = {param.Value}");
                sb.AppendLine($"set {param.ParameterName} = {param.Value} {param.DbType}");
            }
            _logger.Debug(sb.ToString());

            if (duration.TotalSeconds > 1 || interceptionContext.Exception != null)
            {
                using (var db = new EfDbContext())
                {
                    var model = new SQLProfiler()
                    {
                        Query = command.CommandText,
                        Parameters = parameters.ToString(),
                        CommandType = Convert.ToString(command.CommandType),
                        TotalSeconds = (decimal)duration.TotalSeconds,
                        Exception = Convert.ToString(interceptionContext.Exception),
                        InnerException = interceptionContext.Exception == null ? "" : Convert.ToString(interceptionContext.Exception.InnerException),
                        RequestId = 0,
                        FileName = "",
                        CreateDate = DateTime.Now,
                        Active = true
                    };

                    if (db.SQLProfilers.Any(x => x.Query == model.Query && x.Parameters == model.Parameters))
                    {
                        return;
                    }

                    db.SQLProfilers.Add(model);
                    db.SaveChanges();
                }
            }

        }
        #endregion

        #region 计算sql执行耗时方法二
        private void Executing<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            var timer = new Stopwatch();
            interceptionContext.SetUserState("timer", timer);
            timer.Start();
        }

        private void Executed<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            var timer = interceptionContext.FindUserState("timer") as Stopwatch;
            timer?.Stop();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("command used:");
            sb.AppendLine(command.CommandText.Replace(Environment.NewLine, ""));

            StringBuilder parameters = new StringBuilder();
            foreach (DbParameter param in command.Parameters)
            {
                parameters.AppendLine($"{param.ParameterName} {param.DbType} = {param.Value}");
                sb.AppendLine($"set {param.ParameterName} = {param.Value} {param.DbType}");
            }
            _logger.Debug(sb.ToString());

            if (timer?.ElapsedMilliseconds > 1000 || interceptionContext.Exception != null)
            {
                using (var db = new EfDbContext())
                {
                    var model = new SQLProfiler()
                    {
                        Query = command.CommandText,
                        Parameters = parameters.ToString(),
                        CommandType = Convert.ToString(command.CommandType),
                        TotalSeconds = (decimal)timer?.ElapsedMilliseconds,
                        Exception = Convert.ToString(interceptionContext.Exception),
                        InnerException = interceptionContext.Exception == null ? "" : Convert.ToString(interceptionContext.Exception.InnerException),
                        RequestId = 0,
                        FileName = "",
                        CreateDate = DateTime.Now,
                        Active = true
                    };

                    if (db.SQLProfilers.Any(x => x.Query == model.Query && x.Parameters == model.Parameters))
                    {
                        return;
                    }

                    db.SQLProfilers.Add(model);
                    db.SaveChanges();
                }
            }
        }
        #endregion

    }
}
