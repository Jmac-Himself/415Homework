using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Infrastructure.Model.Entities;
using EnterpriseSystems.Data.Hydraters;
using System;
using System.Data;
using System.Collections.Generic;

namespace EnterpriseSystems.Data.Mappers
{
    public class CommentMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<CommentVO> CommentHydrater { get; set; }
        IQuery NewQuery;
        DataTable dataTable;

        public CommentMapper(IDatabase database, IHydrater<CommentVO> commentHydrater)
        {
            Database = database;
            CommentHydrater = commentHydrater;
        }

        public IEnumerable<CommentVO> GetCommentsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            Database.CreateQuery("SELECT * FROM REQ_ETY_CMM WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I");
            NewQuery.AddParameter(customerRequest, "@CUS_REQ_I");
            dataTable = Database.RunSelect(NewQuery);
            return CommentHydrater.Hydrate(dataTable);
        }
        public IEnumerable<CommentVO> GetCommentsByStop(StopVO Stop)
        {
            Database.CreateQuery("SELECT * FROM REQ_ETY_CMM WHERE ETY_NM = 'REQ_ETY_OGN' AND ETY_KEY_I = @REQ_ETY_OGN_I");
            NewQuery.AddParameter(Stop, "@REQ_ETY_OGN_I");
            dataTable = Database.RunSelect(NewQuery);
            return CommentHydrater.Hydrate(dataTable);
        }
    }
}
