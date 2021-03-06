using System;
using TemplateMaker.Viewer.Helpers.CustomProperty;

namespace TemplateMaker.Viewer.Views.SmartProperty.Editor
{
    interface IFromSmartPropertyEditor: ISmartPropertyEditor
    {
        void DefinePropertyEditor(Type editorType);
    }
}
