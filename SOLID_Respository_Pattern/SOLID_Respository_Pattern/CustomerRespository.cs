using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID_Respository_Pattern
{
    public class CustomerRespository : BaseRepository<Customer, MyDBContext>
    {

        public Customer GetCustomer(int id)
        {
            return Get(filter: t => t.id == id);
        }
         
        public List<Customer> GetCustomerList(int id)
        {
            return GetList(filter: t => t.id == id);
        } 

        public Customer AddCustomer(Customer usr)
        {
            return Add(usr);
        }

        public Customer UpdateCustomer(Customer usr)
        {
            return Update(usr);
        }

        public void DeleteCustomer(Customer usr)
        {
            Delete(usr);
        }
    }
}
