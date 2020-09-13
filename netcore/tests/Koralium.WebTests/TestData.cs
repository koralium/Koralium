/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Koralium.WebTests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests
{
    public class TestData
    {
        public static IQueryable<Test> GetData()
        {
            var o = new List<Test>()
            {
                new Test()
                {
                    Name = "test",
                    TestList = new List<int>()
                    {
                        1,
                        5
                    },
                    ListInList = new List<List<int>>()
                    {
                        new List<int>()
                        {
                            6,
                            7
                        }
                    },
                    TestObject = new TestObject()
                    {
                        TestTest = "testar1",
                        OtherObject = new OtherObject()
                        {
                            Name = "other"
                        }
                    },
                    ListOfObject = new List<OtherObject>()
                    {
                        new OtherObject()
                        {
                            Name = "test"
                        },
                        new OtherObject()
                        {
                            Name = "test2"
                        }
                    },
                    BoolValue = true,
                    FloatValue = 3.0f
                },
                new Test()
                {
                    Name = "test2",
                    TestList = new List<int>()
                    {
                        2,
                        6
                    },
                    ListInList = new List<List<int>>()
                    {
                        new List<int>()
                        {
                            7,
                            8
                        }
                    },
                    TestObject = new TestObject()
                    {
                        TestTest = "testar2",
                        OtherObject = new OtherObject()
                        {
                            Name = "other2"
                        }
                    },
                    ListOfObject = new List<OtherObject>()
                    {
                        new OtherObject()
                        {
                            Name = "test2"
                        },
                        new OtherObject()
                        {
                            Name = "test3"
                        }
                    },
                    BoolValue = false,
                    FloatValue = 7.0f
                }
            }.AsQueryable();

            return o;
        }

        public static IQueryable<Secure> GetSecureData()
        {
            return new List<Secure>()
            {
                new Secure()
                {
                    Name = "test1"
                },
                new Secure()
                {
                    Name = "test2"
                }
            }.AsQueryable();
        }

        public static IQueryable<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Name = "test employee",
                    CompanyId = "1"
                },
                new Employee()
                {
                    Name = "Employee null company",
                    CompanyId = null
                }
            }.AsQueryable();
        }

        public static IQueryable<Company> GetCompanies()
        {
            return new List<Company>()
            {
                new Company()
                {
                    Name = "test company",
                    CompanyId = "1"
                },
                new Company()
                {
                    Name = "other company",
                    CompanyId = "2"
                }
            }.AsQueryable();
        }
    }
}
