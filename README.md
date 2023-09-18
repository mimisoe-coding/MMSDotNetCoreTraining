> pagination 

```
declare @pageRowCount int, @pageCount int
select @pageRowCount = Count(BlogId) from Tbl_Blog

declare @pageNo int = 1
declare @pageSize int = 5
select * from [dbo].[Tbl_Blog]
Order By BlogId
OFFSET (@pageNo-1) * @pageSize ROWS
FETCH NEXT @pageSize ROWS ONLY

select @pageCount = @pageRowCount / @pageSize
if(@pageRowCount % @pageSize > 0)
set @pageCount = @pageCount + 1
select @pageCount
```

https://datatables.net/examples/basic_init/zero_configuration.html  `Data Table`

https://cdn.dribbble.com/users/2138219/screenshots/5088732/pagination.gif 

https://www.dotnettricks.com/learn/mvc/viewdata-vs-viewbag-vs-tempdata-vs-session `ViewData/ViewBag/TempData/Session`

https://www.c-sharpcorner.com/article/asp-net-mvc-jquery-ajax-datatables-with-dynamic-columns/ `jQuery ajax datatables`

https://www.sqlshack.com/pagination-in-sql-server/ `Pagination`

https://www.jsdelivr.com/package/npm/jquery `jquery cdn`

https://stackoverflow.com/questions/5980389/proper-way-to-use-ajax-post-in-jquery-to-pass-model-from-strongly-typed-mvc3-vie `AJAX Post in jquery`

https://api.jquery.com/jquery.ajax/ `jQuery.ajax()`

https://stackoverflow.com/questions/377644/jquery-ajax-error-handling-show-custom-exception-messages `jQuery Ajax Error Handling`

https://api.jquery.com/jquery.each/ `jQuery.each()`

https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-7.0 `Cross-Origin Requests(CORS)`

https://i.stack.imgur.com/M0le5.jpg `Service Lifetime`

***.NET 7 C# Version 11***
=============

> - Console App
> - Ado.Net (SqlClient)
> - Dapper
> - EFCore  
> RepoDB

> - Asp.Net Core Web Api (Rest Api)  
	> - Ado.Net  
	> - EF  
	> - Dapper  

> - ***Postman (Test [Get, Post, Put, Patch, Delete], Export, Import)***

> - Api Call [Console] Client > Server  
	> - HttpClient [Get, Post, Put, Patch, Delete]  
	> - RestClient (https://restsharp.dev/)  
	> - Refit  
---
> - ***html, css, javascript, jquery, bootstrap, ajax (basic)***

- `Button (ladda button)`  
https://github.com/msurguy/ladda-bootstrap  
https://msurguy.github.io/ladda-bootstrap/  

- `Checkbox, Radio (icheck)`  
https://github.com/bantikyan/icheck-bootstrap  
https://www.jsdelivr.com/package/npm/icheck-bootstrap  
https://bantikyan.github.io/icheck-bootstrap/  

- `Alert box`  
https://sweetalert2.github.io/#download  
https://notiflix.github.io/  

- `Toast`  
https://apvarun.github.io/toastify-js/#  
https://github.com/apvarun/toastify-js/blob/master/README.md  

- `Datepicker`  
https://fengyuanchen.github.io/datepicker/  
https://github.com/fengyuanchen/datepicker/blob/master/README.md  
https://github.com/fengyuanchen/datepicker/releases/tag/v1.0.10  

- `Table`

---


