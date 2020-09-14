import { QueryBuilder } from "../src/queryBuilder"
import { ObjectToSelectMapper } from "../src/objectToSelectMapper" 

test("count with filter", () => {
  const expected = "SELECT count(*) FROM testtable WHERE name = 'test'"
  const result = new QueryBuilder("testtable")
    .addSelectElement("count(*)")
    .setFilter("name = 'test'")
    .build();

    expect(result).toEqual(expected);
});

test("Select same column", () => {
  const expected = "SELECT column FROM testtable";
  const result = new QueryBuilder("testtable")
    .addSelectElement("column")
    .addSelectElement("column")
    .build();

    expect(result).toEqual(expected);
});

test("Select with limit and offset", () => {
  const expected = "SELECT * FROM testtable LIMIT 100 OFFSET 200";
  const result = new QueryBuilder("testtable")
    .addSelectElement("*")
    .setLimit(100)
    .setOffset(200)
    .build();

    expect(result).toEqual(expected);
});

test("Select multiple columns, filter, limit, offset", () => {
  const expected = "SELECT column1, column2 FROM testtable WHERE name = 'test' LIMIT 100 OFFSET 200";
  const result = new QueryBuilder("testtable")
    .setFilter("name = 'test'")
    .addSelectElement("column1")
    .addSelectElement("column2")
    .setLimit(100)
    .setOffset(200)
    .build();

    expect(result).toEqual(expected);
});

test("Object mapper", () => {
  const mapper = new ObjectToSelectMapper()
    .addMapping("c1", "c1")
    .addMapping("c2", ["c2", "c3"]);

  const queryBuilder = new QueryBuilder("testtable");
  mapper.addSelectsToQuery(queryBuilder, {
    c1: {},
    c2: {}
  });
  const result = queryBuilder.build();
  const expected = "SELECT c1, c2, c3 FROM testtable";

  expect(result).toEqual(expected);
});

test("Object mapper, missing mapping", () => {
  const mapper = new ObjectToSelectMapper()
    .addMapping("c1", "c1")
    .addMapping("c2", ["c2", "c3"]);

  const queryBuilder = new QueryBuilder("testtable");
  mapper.addSelectsToQuery(queryBuilder, {
    c1: {},
    c2: {},
    c3: {},
    c4: {}
  });
  
  const result = queryBuilder.build();
  const expected = "SELECT c1, c2, c3 FROM testtable";

  expect(result).toEqual(expected);
});