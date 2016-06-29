# exPanda
Stop repeating yourself!

![exPanda](http://jamesstuddart.co.uk/Content/Images/exPanda-round.png)

exPanda is a light weight library of commonly required methods, available as extension methods on your objects. 

## Setup

Simply build the solution and add the DLL to your projects

## Usage

---
### exPanda.Extensions

#### Class Extensions
##### MapTo()
Maps any objects to another object, a very simplistic automapper
*It does not map child objects*

strict mode, means that the properities you are mapping from and to have to be the same types, if you turn it off .Net will try and convert them for you where it can.

##### GetDescription()
Returns the value in the **DescriptionAttribute** attribute of a class


#### Collection Extensions
##### ToDataTable()
Converts a collection of objects to a datatable
*It does not map child objects*

##### CreateTable<T>()
Turns single object to a datatable
*It does not map child objects*

#### Datetime Extensions
##### IsBusinessDay()
Returns if the DateTime *IS* a business day. *(based in UK business days)*

##### BusinessDaysSince
Return how many business days have occured since the DateTime provided. *(based in UK business days)*

##### BusinessDaysTo
Return how many business days until the DateTime provided. *(based in UK business days)*


#### DataReader Extensions
##### MapTo()
Maps a Datareader to a List<T> of the define type.

#### Dictionary Extensions
##### ToSqlParameters()
Returns a List<SqlParameters> from a dictionary

#### Enum Extensions
##### GetDescription()
Returns the value in the **DescriptionAttribute** attribute of a class

##### CamelCaseToHumanReadable()
Returns a string version of an enum name correctly formatted, with spaces (based on correct capitalisation) 

#### List Extensions

##### ChunkBy()
Break any List of objects into chunks, great for processing large amounts of data with multiple processes.

##### DistinctBy()
Return a List<T> of objects, which are distinct by a single value. 

#### String Extensions
##### ToMD5Hash()
Convert a string to an MD5 hash quickly

##### CamelCaseToHumanReadable()
Returns a human reable string version of the originating string correctly formatted, with spaces (based on correct capitalisation) 

##### IsNumeric()
Check to see if a string is a numeric value

##### ToTitleCase()
Changes a string to Title case

##### RemoveAccent()
Remove accents from characters when you are unable to work with them

##### ToUrlFormat()
Changes a string into a URL friendly version, by removing illegal characters and replacing spaces with dashes

##### ToType()
Will Force the conversion of a string into the required type *(I cannot remember what I made this one for)*

##### Concatenate()
Simple concatenates an array of strings to a string string, separating them by the provided character.

##### ToSecureString()
Converts a string to a secure string

---
### exPanda.Web
Web specific extensions

#### Html Extensions
##### ToHtmlTable()
Convert a DataReader or DataTable to a html table
