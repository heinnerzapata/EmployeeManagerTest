using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using db_employeeEntities;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace EmployeesV1.DAL
{
    public class EmployeeDAL
    {


        public List<EmployeesV1.Models.Project> getProjects()
        {

            List<EmployeesV1.Models.Project> Projetcs = new List<EmployeesV1.Models.Project>();

            //EmployeeV2Entities employeeApp = new EmployeeV2Entities();
            DB_A162E1_zemogatestEntities employeeApp = new DB_A162E1_zemogatestEntities();

            employeeApp.Database.Connection.Open();

            DataTable dt = new DataTable();
            var connectionState = employeeApp.Database.Connection.State;
            var conn = employeeApp.Database.Connection;

            try
            {
                using (employeeApp)
                {
                    if (connectionState != ConnectionState.Open)
                        conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "getProjects";
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Projetcs.Add(new EmployeesV1.Models.Project()
                                {

                                    ProjId = System.Convert.ToInt16(dr["ProjId"]),
                                    ProjDesc = dr["ProjDesc"].ToString(),

                                });

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connectionState != ConnectionState.Open)
                    conn.Close();

            }


            return Projetcs;
        }



        public List<EmployeesV1.Models.Position> getPositions()
        {

            List<EmployeesV1.Models.Position> Positions = new List<EmployeesV1.Models.Position>();

            //EmployeeV2Entities employeeApp = new EmployeeV2Entities();
            DB_A162E1_zemogatestEntities employeeApp = new DB_A162E1_zemogatestEntities();

            employeeApp.Database.Connection.Open();

            DataTable dt = new DataTable();
            var connectionState = employeeApp.Database.Connection.State;
            var conn = employeeApp.Database.Connection;

            try
            {
                using (employeeApp)
                {
                    if (connectionState != ConnectionState.Open)
                        conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "getPositions";
                        cmd.CommandType = CommandType.StoredProcedure;
                                            
                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Positions.Add(new EmployeesV1.Models.Position()
                                {

                                    PosId = System.Convert.ToInt16(dr["PosId"]),
                                    PosDesc = dr["PosDesc"].ToString(),
                                   
                                });

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connectionState != ConnectionState.Open)
                    conn.Close();

            }


            return Positions;
        }


        public List<EmployeesV1.Models.Employee> CRUDEmployee(int OP, int EmploId, string EmploPicture , string EmploName , int EmploPosition , int EmploProj)
        {
            //EmployeeV2Entities employeeApp = new EmployeeV2Entities();
            DB_A162E1_zemogatestEntities employeeApp = new DB_A162E1_zemogatestEntities();

            employeeApp.Database.Connection.Open();

            List<EmployeesV1.Models.Employee>Employees =  new List<EmployeesV1.Models.Employee>();


            DataTable dt = new DataTable();
            var connectionState = employeeApp.Database.Connection.State;
            var conn = employeeApp.Database.Connection;

            try
            {
                using (employeeApp)
                {
                    if (connectionState != ConnectionState.Open)
                        conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "EmployeeCRUD";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("OP", OP.ToString()));
                        cmd.Parameters.Add(new SqlParameter("EmploId", EmploId.ToString()));
                        cmd.Parameters.Add(new SqlParameter("EmploPicture", EmploPicture));
                        cmd.Parameters.Add(new SqlParameter("EmploName", EmploName));
                        cmd.Parameters.Add(new SqlParameter("EmploPosition", EmploPosition.ToString()));
                        cmd.Parameters.Add(new SqlParameter("EmploProj", EmploProj.ToString()));

                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Employees.Add(new EmployeesV1.Models.Employee() {

                                    EmploId = System.Convert.ToInt16(dr["EmploId"]),
                                    EmploName = dr["EmploName"].ToString(),
                                    EmploPicture = dr["EmploPicture"].ToString(),
                                    EmploPosition = System.Convert.ToInt16(dr["EmploPosition"]),
                                    PosDesc = dr["PosDesc"].ToString(),
                                    EmploProj = System.Convert.ToInt16(dr["EmploProj"]),
                                    ProjDesc = dr["ProjDesc"].ToString(),
                                    ErrMsg = dr["ProjDesc"].ToString()

                                }); 

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connectionState != ConnectionState.Open)
                    conn.Close();                                

            }
            
            return Employees;
        }





    }
}