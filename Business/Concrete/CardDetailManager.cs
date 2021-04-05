using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CardDetailManager : ICardDetailService
    {
        ICardDetailDal _cardDetailDal;

        public CardDetailManager(ICardDetailDal cardDetailDal)
        {
            _cardDetailDal = cardDetailDal;
        }

        public IResult AddCard(CardDetail cardDetail)
        {
            _cardDetailDal.Add(cardDetail);
            return new SuccessResult(Messages.CardAdded);
        }

        public IResult DeleteCard(string cardNumber)
        {
            var cardToDelete = _cardDetailDal.Get(c => c.CardNumber == cardNumber);
            _cardDetailDal.Delete(cardToDelete);
            return new SuccessResult(Messages.CardDeleted);
        }

        public IDataResult<List<CardDetail>> GetCardsByUserId(int userId)
        {
            return new SuccessDataResult<List<CardDetail>>(_cardDetailDal.GetAll(c => c.UserId == userId));
        }
    }
}
