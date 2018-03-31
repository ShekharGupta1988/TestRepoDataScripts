private static string GetQuery(OperationContext cxt)
{
    return
    $@"AntaresIISLogFrontEndTable
        | where {Utilities.TimeAndTenantFilterQuery(cxt)}
        | where Sc_status == 503
        | summarize count() by bin(PreciseTimeStamp, 5m)";
}

[Definition(Id = "RandomErrors", Name = "Random Errors", Description = "")]
public async static Task<Response> Run(DataProviders dp, OperationContext cxt, Response res)
{
    res.Dataset.Add(new DiagnosticData()
    {
        Table = await dp.Kusto.ExecuteQuery(GetQuery(cxt), cxt.Resource.Stamp)
    });

    return res;
}