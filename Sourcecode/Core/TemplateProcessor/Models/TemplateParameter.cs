﻿using System.Collections.Generic;

namespace TemplateProcessor.Models
{
    public enum ETemplateParameterType
    {
        //Basic types
        String,
        Integer,
        Boolean,
        Object,

        //Schema types
        TableInfo,

        //Api types
        ApiInfo
    }

    public class TemplateParameter
    {
        public string Name { get; set; }
        public ETemplateParameterType Type { get; set; } = ETemplateParameterType.String;
        public bool Required { get; set; } = true;
        public object Value { get; set; }
        public bool IsCollection { get; set; } = false;
        public IEnumerable<TemplateParameter> Parameters { get; set; }
    }
}