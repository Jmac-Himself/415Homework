using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Infrastructure.Model.Entities;
using EnterpriseSystems.Data.Hydraters;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnterpriseSystems.Data.Mappers
{
    public class CustomerRequestMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<CustomerRequestVO> CustomerRequestHydrater { get; set; }
        IQuery NewQuery;
        DataTable dataTable;

        public CustomerRequestMapper(IDatabase database, IHydrater<CustomerRequestVO> customerRequestHydrater)
        {
            Database = database;
            CustomerRequestHydrater = customerRequestHydrater;
        }

        public IEnumerable<CustomerRequestVO> GetCustomerRequestByIdentity(int CustomerRequestIdentity)
        {
            Database.CreateQuery("SELECT * FROM CUS_REQ WHERE CUS_REQ_I = @CUS_REQ_I");
            NewQuery.AddParameter(CustomerRequestIdentity, "CUS_REQ_I");
            dataTable = Database.RunSelect(NewQuery);
            return CustomerRequestHydrater.Hydrate(dataTable);
        }

        public IEnumerable<CustomerRequestVO> GetCustomerRequestsByReferenceNumber(string ReferenceNumber)
        {
            Database.CreateQuery("SELECT A.* FROM CUS_REQ A, REQ_ETY_REF_NBR B WHERE "
                                    + "B.ETY_NM = 'CUS_REQ' AND B.ETY_KEY_I = A.CUS_REQ_I AND "
                                    + "B.REF_NBR = @REF_NBR");
            NewQuery.AddParameter(ReferenceNumber, "@REF_NBR");
            dataTable = Database.RunSelect(NewQuery);
            return CustomerRequestHydrater.Hydrate(dataTable);
        }

        public IEnumerable<CustomerRequestVO> GetCustomerRequestsByReferenceNumberAndBusinessName(string referenceNumber, string businessName)
        {
            Database.CreateQuery("");
            NewQuery.AddParameter(businessName, "@BUS_UNT_KEY_CH");
            NewQuery.AddParameter(referenceNumber, "@REF_NBR");
            dataTable = Database.RunSelect(NewQuery);
            return CustomerRequestHydrater.Hydrate(dataTable);
        }
    }
}
