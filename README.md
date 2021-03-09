# TemplateMaker
TemplateMaker was created to supply the need of having projects/code created automatically by the TemplateMaker.
The idea is make implementation of usual code faster.
I know that we have the CookieCutter or Moustache, but my code uses an logic that helps to configure and create the Template.
Also has an Intergace that can run on Windows (for know, I'll turn this in a React application) that generates the files for you.


For instance, the Parameter ProjectName can be called like this: {{ProjectName}}

In the file name:
`{{ProjectName}}Project.csprj`

Or inside the file:
`namespace {{ProjectName}}.Models`
 

#Using collection of values
You can setup a collection of values using the property `IsCollection` as True at the Parameter.
The Type of the Parameter will define with type of collection is that, example:
```{
     Parameter: ParamTest,
     Type: String
     IsCollection: True
}```
This will generate a Collection of Strings.

To use the Parameter in the template, you can do like this:

In the file name:
``

Inside the file:
``


Eu sou o {{AppName}}

{{PascalCase ProjectName}}

{{OracleToCSharp ColumnType}}
