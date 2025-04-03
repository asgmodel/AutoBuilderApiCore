﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace AutoGenerator
{
    public interface ITModel { }

    public interface ITBase
    {
      
    }



    public interface ITDso : ITBase { }

    public interface ITDto : ITBase { }

    public interface ITShareDto : ITDto { }

    public interface ITBuildDto : ITDto { }

    public interface ITVM : ITBase { }

    public interface ITTransient : ITBase { }

    public interface ITSingleton : ITBase { }

    public interface ITScope : ITBase { }

    public interface ITRepository : ITBase { }

    public interface ITBaseRepository : ITRepository { }

    public interface ITBuildRepository : ITRepository { }

    public interface ITBaseShareRepository : ITRepository, ITScope { }

    public interface ITService : ITBase,ITScope { }

    public interface ITBaseService : ITService { }



    public interface ITranslationData
    {
        Dictionary<string, string>? Value { get; set; }


        string? ToFilter(string? lg);
    }

}

