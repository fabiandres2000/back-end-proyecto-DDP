using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;
using Domain;
using Domain.Factory;
using Domain.Entity;

namespace Domain.Interfaces
{
    public interface IGenericFactory<T> where T : BaseEntity
    {
        T CreateEntity(int type, IPersonaRequest request);
    }
}
