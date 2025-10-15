using System;
using System.Reflection;

namespace TP_API_Progra_3_equipo_22B.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}