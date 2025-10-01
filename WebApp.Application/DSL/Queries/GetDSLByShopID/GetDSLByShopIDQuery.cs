using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Application.DSL.Queries.GetDSLByShopID
{
    public class GetDSLByShopIDQuery : IRequest<DSLDTO>
    {
        public int ShopID { get; set; }
        public GetDSLByShopIDQuery(int shopID)
        {
            ShopID = shopID;
        }
    } 
}
