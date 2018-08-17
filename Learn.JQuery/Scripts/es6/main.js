
////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
// follow this instruction to setup  es6 for ASP.NET MVC 5
//https://www.slightedgecoder.com/2017/05/22/setting-es6-environment-asp-net-mvc-5/






import Person from './person';

var person = new Person("Frank", 20);
person.speak();


$(document).ready(function () {
    console.log('test');
    $('table tr').each(function() {
        console.log($(this).html());
    });

    $('#first td:first-child,#first td:last-child').css('background-color','yellow');
    $('#second tr:even').css('background-color','gray');
});