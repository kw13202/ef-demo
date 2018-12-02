using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DbTransactionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // DbContextTransatction 仅适用于DbContext上下文使用
            //using (var ctx = new EfDbContext())
            //{
            //    ctx.Database.Log = Console.WriteLine;
            //    using (var tran = ctx.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            ctx.FlighBookings.Add(new Model.FlighBooking()
            //            {
            //                FlightName = "航班01",
            //                Number = "航班号01",
            //                TravellingDate = DateTime.Now
            //            });
            //            ctx.SaveChanges();
            //            tran.Commit();

            //            Console.WriteLine("success");
            //        }
            //        catch (Exception e)
            //        {
            //            tran.Rollback();
            //            Console.WriteLine(e.Message);
            //        }
            //    }
            //}

            // DbTransatcation 作用于底层DbConnection对象
            //using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            //{
            //    conn.Open();
            //    using (var tran = conn.BeginTransaction())
            //    {
            //        try
            //        {
            //            using (var ctx = new EfDbContext(conn))
            //            {
            //                ctx.Database.Log = Console.WriteLine;
            //                ctx.Database.UseTransaction(tran);
            //                ctx.Reservations.Add(new Model.Reservation()
            //                {
            //                    Name = "酒店01",
            //                    BookingDate = DateTime.Now
            //                });
            //                ctx.SaveChanges();
            //            }
            //            tran.Commit();
            //        }
            //        catch (Exception ex)
            //        {
            //            tran.Rollback();
            //            Console.WriteLine(ex.Message);
            //        }
            //    }
            //}

            //TransactionScope分布式事务
            // 1.添加System.Transatction引用
            // 2.开启Distributed Transaction Coordinator服务
            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                FlightDbContext flightContext = new FlightDbContext();
                HotelDbContext hotelContext = new HotelDbContext();
                try
                {
                    // 航班信息
                    flightContext.FlighBookings.Add(new Model.FlighBooking()
                    {
                        FlightName = "分布式-航班01",
                        Number = "分布式-航班号01",
                        TravellingDate = DateTime.Now
                    });

                    // 预约信息
                    hotelContext.Reservations.Add(new Model.Reservation()
                    {
                        Name = "分布式预约01",
                        BookingDate = DateTime.Now
                    });

                    flightContext.SaveChanges();
                    hotelContext.SaveChanges();

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
