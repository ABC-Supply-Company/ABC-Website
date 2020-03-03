using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ABCSupplyCompany.Models;

namespace ABCSupplyCompany.Repositories
{
    public class InventoryAction    {
        public static List<InventoryItem> GetAllInventoryItems(string connString)
        {
            var count = 0;
            var invAll = new List<InventoryItem>();
            var strCon = connString;
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from Inventory where active=1";
                    cmd.Connection = conn;
                    conn.Open();


                    try
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                var invItem = new InventoryItem();

                                invItem.id = Int32.Parse(rdr["id"].ToString()); 
                                invItem.lottag_number = rdr["lottag_number"].ToString();
                                invItem.lottag_description = rdr["lottag_description"].ToString();
                                invItem.weight_net = rdr["weight_net"].ToString();
                                invItem.on_hand_balance = rdr["on_hand_balance"].ToString();
                                invItem.unit_of_measure = rdr["unit_of_measure"].ToString();

                                invAll.Add(invItem);
                                count++;
                            }
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        
                    }

                }
            }
            var numRecords = count;
            return invAll;
        }

        internal static InventoryItem GetInventoryItem(string connString, int id)
        {

            var strCon = connString;
            var invItem = new InventoryItem();
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from Inventory where id="+ id;
                    cmd.Connection = conn;
                    conn.Open();
                    try
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                
                                invItem.id = Int32.Parse(rdr["id"].ToString());
                                invItem.lottag_number = rdr["lottag_number"].ToString();
                                invItem.lottag_description = rdr["lottag_description"].ToString();
                                invItem.weight_net = rdr["weight_net"].ToString();
                                invItem.on_hand_balance = rdr["on_hand_balance"].ToString();
                                invItem.unit_of_measure = rdr["unit_of_measure"].ToString();
                                invItem.active = rdr.GetBoolean("active");                                
                            }
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {

                    }

                }
            }
            return invItem;
        }

        internal static bool CreateInventoryItem(string connString, InventoryItem item)
        {
            bool isCreated = false;
            var intRecordCount = 0;
            var strCon = connString;
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                string sql = $"Insert Into inventory (lottag_number,lottag_description, weight_net,  on_hand_balance, unit_of_measure, active) Values ('{item.lottag_number}', '{item.lottag_description}','{item.weight_net}','{item.on_hand_balance}','{item.unit_of_measure}','{item.active}')";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        intRecordCount = command.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (intRecordCount > 0)
                {
                    isCreated = true;
                }
            }
            return isCreated;
        }

        internal static bool UpdateInventoryItem(string connString, InventoryItem item )
        {
            bool isUpdated = false;
            var intRecordCount = 0;
            var strCon = connString;
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                string sql = $"Update inventory SET lottag_number='{item.lottag_number}', lottag_description='{item.lottag_description}', weight_net='{item.weight_net}', on_hand_balance='{item.on_hand_balance}' , unit_of_measure ='{item.unit_of_measure}', active ='{item.active}' Where id='{item.id}'";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        intRecordCount = command.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (intRecordCount > 0)
                {
                    isUpdated = true;
                }
            }
            return isUpdated;
        }

        internal static bool DeleteInventoryItem(string connString, int id)
        {
            bool isDeleted = false;
            var intRecordCount = 0;
            var strCon = connString;
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                string sql = $"Delete from inventory Where id="+id;
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        intRecordCount = command.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (intRecordCount > 0)
                {
                    isDeleted = true;
                }
            }
            return isDeleted;
        }

        public static List<InventoryItem> GetFullInventory(string connString)
        {
            var count = 0;
            var invAll = new List<InventoryItem>();
            var strCon = connString;
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from Inventory";
                    cmd.Connection = conn;
                    conn.Open();


                    try
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                var invItem = new InventoryItem();

                                invItem.id = Int32.Parse(rdr["id"].ToString());
                                invItem.lottag_number = rdr["lottag_number"].ToString();
                                invItem.lottag_description = rdr["lottag_description"].ToString();
                                invItem.weight_net = rdr["weight_net"].ToString();
                                invItem.on_hand_balance = rdr["on_hand_balance"].ToString();
                                invItem.unit_of_measure = rdr["unit_of_measure"].ToString();
                                invItem.active = rdr.GetBoolean("active");

                                invAll.Add(invItem);
                                count++;
                            }
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {

                    }

                }
            }
            var numRecords = count;
            return invAll;
        }
    }
}
