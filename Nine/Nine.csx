private static string GetQuery(OperationContext cxt)
{
    return
    $@"RoleInstanceHeartbeat | take 2 | project TIMESTAMP, Details";
}

[Definition(Id = "Nine", Name = "", Description = "")]
public async static Task<Response> Run(DataProviders dp, OperationContext cxt, Response res)
{
    res.Dataset.Add(new DiagnosticData()
    {
            Table = await dp.Kusto.ExecuteQuery(GetQuery(cxt), cxt.Resource.Stamp)
    });

    return res;
}
