﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// Этот исходный код был создан с помощью xsd, версия=4.6.1055.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="1S")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="1S", IsNullable=false)]
public partial class Данные {
    
    private ДанныеКомпания[] компанияField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Компания")]
    public ДанныеКомпания[] Компания {
        get {
            return this.компанияField;
        }
        set {
            this.компанияField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="1S")]
public partial class ДанныеКомпания {
    
    private ДанныеКомпанияПродукция[] продукцияField;
    
    private int кодField;
    
    private string наименованиеField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Продукция")]
    public ДанныеКомпанияПродукция[] Продукция {
        get {
            return this.продукцияField;
        }
        set {
            this.продукцияField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int код {
        get {
            return this.кодField;
        }
        set {
            this.кодField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string наименование {
        get {
            return this.наименованиеField;
        }
        set {
            this.наименованиеField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="1S")]
public partial class ДанныеКомпанияПродукция {
    
    private int кодField;
    
    private string наименованиеField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int код {
        get {
            return this.кодField;
        }
        set {
            this.кодField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string наименование {
        get {
            return this.наименованиеField;
        }
        set {
            this.наименованиеField = value;
        }
    }
}
