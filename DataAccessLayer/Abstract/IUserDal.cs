using Core.DataAccessLayer.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal : IEntityRepositoryBase<User>
    {
        List<OperationClaim> GetOperationClaims(User user);
    }
}
