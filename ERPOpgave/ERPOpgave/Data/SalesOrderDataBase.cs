using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPOpgave.Order;

namespace ERPOpgave.Data;

partial class Database
{
    List<SalesOrder> list = new List<SalesOrder>();
    static int nextId = 1;
    public void InsertSalesOrder(SalesOrder ord)
    {
        list.Add(ord);
        ord.OrderNumber = nextId++;
    }
    public void RemoveSalesOrder(SalesOrder ord)
    {
        foreach (SalesOrder s in list)
        {
            if (s.OrderNumber == ord.OrderNumber)
            {
                list.Remove(s);
            }
        }
    }
    public void UpdateSalesOrder(SalesOrder ord)
    {
        foreach (SalesOrder s in list)
        {
            if (s.OrderNumber == ord.OrderNumber)
            {
                list.Remove(s);
                list.Add(ord);
            }
        }
    }
    public SalesOrder FindSalesOrder(int id)
    {
        foreach (SalesOrder Order in list)
        {
            if (Order.OrderNumber == id)
            {
                return Order;
            }
        }
        return null;
    }
    public List<SalesOrder> SelectSalesOrder(string where="")
    {
        List<SalesOrder> returnlist = new List<SalesOrder>();
        foreach (SalesOrder Order in list)
        {
            if (Order.OrderNumber == Order.OrderNumber)
            {
                returnlist.Add(Order);
            }
        }
        return returnlist;
    }
}


