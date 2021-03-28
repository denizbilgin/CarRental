using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICardDetailService
    {
        IResult AddCard(CardDetail cardDetail);
        IDataResult<List<CardDetail>> GetCardsByUserId(int userId);
    }
}
