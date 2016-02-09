using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Infrastructure.Model.Entities;
using EnterpriseSystems.Data.Hydraters;
using System;

namespace EnterpriseSystems.Data.Mappers
{
    public class CommentMapper
    {
        private IDatabase Database { get; set; }
        private IHydrater<CommentVO> CommentHydrater { get; set; }

        public CommentMapper(IDatabase database, IHydrater<CommentVO> commentHydrater)
        {
            Database = database;
            CommentHydrater = commentHydrater;
        }

        public CommentVO GetCommentsByCustomerRequest(CommentVO Comment)
        {
            throw new NotImplementedException();
        }
        public CommentVO GetCommentsByStop(CommentVO Comment)
        {
            throw new NotImplementedException();
        }
    }
}
