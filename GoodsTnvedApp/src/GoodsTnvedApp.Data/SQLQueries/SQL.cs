namespace GoodsTnvedApp.Data.SQLQueries;

public static class SQL
{
    public static string GetGoods = @"WITH RecursiveTree AS (
    SELECT 
        id, 
        code, 
        defis, 
        name, 
        parent_id
    FROM GoodsTnved
    WHERE code = @Code
    UNION ALL
    SELECT 
        g.id, 
        g.code, 
        g.defis, 
        g.name, 
        g.parent_id
    FROM GoodsTnved g
    INNER JOIN RecursiveTree r ON g.id = r.parent_id
)
SELECT 
    id,
    code,
    defis,
    name,
    parent_id AS parentId
FROM RecursiveTree;
";
}