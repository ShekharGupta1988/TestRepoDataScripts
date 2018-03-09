private static string GetQuery(OperationContext cxt)
{
    return
    $@"AntaresBillingControllerEvents | take 2 | project TIMESTAMP, Role";
}

[Definition(Id = "Five1", Name = "", Description = "")]
public async static Task<Response> Run(DataProviders dp, OperationContext cxt, Response res)
{
    res.Dataset.Add(new DiagnosticData()
    {
            Table = await dp.Kusto.ExecuteQuery(GetQuery(cxt), cxt.Resource.Stamp)
    });

    return res;
}
