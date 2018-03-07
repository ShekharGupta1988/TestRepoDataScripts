private static string GetQuery(OperationContext cxt)
{
    return
    $@"AntaresAdminControllerEvents | take 1 | project TIMESTAMP, SourceMoniker";
}

[Definition(Id = "Two", Name = "", Description = "")]
public async static Task<Response> Run(DataProviders dp, OperationContext cxt, Response res)
{
    res.Dataset.Add(new DiagnosticData()
    {
            Table = await dp.Kusto.ExecuteQuery(GetQuery(cxt), cxt.Resource.Stamp)
    });

    return res;
}
