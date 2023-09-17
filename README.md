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