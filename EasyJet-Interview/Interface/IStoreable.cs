using System;
using System.Data;
using System.Collections;

namespace EasyJet.Interview.Interface
{
    public interface IStoreable<T>
    {
        T Id { get; set; }
    }
    
}