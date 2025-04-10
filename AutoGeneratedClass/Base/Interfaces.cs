﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace AutoGeneratedClass
{
    public interface ITModel { }

    public interface ITGenerator
    {
        void Generate(SyntaxNode node);
    }



    public interface ITDso : ITGenerator { }

    public interface ITDto : ITGenerator { }

    public interface ITShareDto : ITDto { }

    public interface ITBuildDto : ITDto { }

    public interface ITVM : ITGenerator { }

    public interface ITTransient : ITGenerator { }

    public interface ITSingleton : ITGenerator { }

    public interface ITScope : ITGenerator { }

    public interface ITRepository : ITGenerator { }

    public interface ITBaseRepository : ITRepository { }

    public interface ITBuildRepository : ITRepository { }

    public interface ITShareRepository : ITRepository { }

    public interface ITService : ITGenerator { }

    public interface ITBaseService : ITService { }





}

