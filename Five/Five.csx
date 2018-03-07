private static string GetQuery(OperationContext cxt)
{
    return
    $@"AntaresBillingControllerEvents | take 1 | project TIMESTAMP, SourceMoniker";
}

[Definition(Id = "Five", Name = "", Description = "")]
public async static Task<Response> Run(DataProviders dp, OperationContext cxt, Response res)
{
    res.Dataset.Add(new DiagnosticData()
    {
            Table = await dp.Kusto.ExecuteQuery(GetQuery(cxt), cxt.Resource.Stamp)
    });

    return res;
}
