﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        [SecuredOperation("admin")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UsersListed);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        [SecuredOperation("admin,user")]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        [SecuredOperation("admin,user")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        [ValidationAspect(typeof(UserValidator))]
        [SecuredOperation("admin,user")]
        public IResult UpdateInfo(User user)
        {
            var userToUpdate = GetById(user.Id).Data;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            Update(userToUpdate);
            return new SuccessResult(Messages.ProfileUpdated);
        }

        public IDataResult<User> GetUserFindexByUserId(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        [CacheRemoveAspect("IUserService.Get")]
        public IResult UpdateUserFindex(int userId)
        {
            var userToUpdateFindex = _userDal.Get(u => u.Id == userId);
            userToUpdateFindex.Findex += 200;
            _userDal.Update(userToUpdateFindex);
            return new SuccessResult(Messages.EarnedFindex);
        }
    }
}
