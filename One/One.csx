private static string GetQuery(OperationContext cxt)
{
    return
    $@"AntaresIISLogFrontEndTable | take 1 | project TIMESTAMP, SourceMoniker";
}

[Definition(Id = "One", Name = "", Description = "")]
public async static Task<Response> Run(DataProviders dp, OperationContext cxt, Response res)
{
    res.Dataset.Add(new DiagnosticData()
    {
            Table = await dp.Kusto.ExecuteQuery(GetQuery(cxt), cxt.Resource.Stamp)
    });

    return res;
}
