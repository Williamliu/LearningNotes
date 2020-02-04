using System;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace JsonNetTest
{
    public static class DHelper
    {
        public static string GetTypeString(this IDictionary<Type, string> dict, Type type)
        {
            if (dict.ContainsKey(type))
                return dict[type];
            else
                return string.Empty;
        }
    } 
    public class MYID
    {
        public string id { get; set; }
    }
    public class YYMM
    {
        public int year { get; set; }
        public int month { get; set; }
    }
    public enum JTYPE
    {
        JObject = 1,
        JArray = 2
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

string json = "{'admin':'2018-11-23 13:30', 'hello': {}, 'sdate':{year:2018, month:12}, 'male':'FaLSE', score:[21,23,35]}";
JObject jobj = JObject.Parse(json);
                //Console.WriteLine("Value: {0} - Type: {1}", jobj.Value<JObject>(), jobj.Value<JArray>("score").ToObject<int[]>().GetType());
                //Console.WriteLine();
                //Console.WriteLine("Value: {0} - Type: {1}", jobj.GetValue("admin"), jobj["admin"].GetType());
                //Console.WriteLine();
JToken jp11 = jobj.Value<JToken>("score");
foreach(JProperty jp in jobj.Properties())
{
    Console.WriteLine("JProperty: {0} - {1} - {2} - {3}", jp.Name, jp.Value, jp.Value.GetType(), jp.Values());
}
                Console.WriteLine();
                Console.WriteLine();
                #region JToken Data
                json = @"{
                           'course_editions': {
                              '2014SL': [
                                 {
                                    'grades': {
                                       'course_units_grades': {
                                          '159715': {
                                             '1': {
                                                'value_symbol': '4',
                                                'exam_session_number': 1,
                                                'exam_id': 198172,
                                                'value_description': {'en': 'good'}
                                             }
                                          }
                                       },
                                       'course_grades': {'name': '12+'}
                                    }
                                 },
                                 {
                                    'grades': {
                                       'course_units_grades': {
                                          '159796': {
                                             '1': {
                                                'value_symbol': '5',
                                                'exam_session_number': 1,
                                                'exam_id': 198259,
                                                'value_description': {'en': 'very good'}
                                             }
                                          }
                                       },
                                       'course_grades': {}
                                    }
                                 }
                              ],
                              '2015SL': { year: 2015, month: 12 }
                           },
                           'Customer': 'VIP',
                           'Score': [101, 203, 304, 405],
                           'Teacher': 'Physics'
                        }";
json = @"{
            'course_editions': {
                '2014SL': [20, 22, 33],
                '2015SL': { year: 2015, month: 12, price:20 }
            },
            'Customer': 'VIP User',
            'price': 18,
            'Score': [{id: 101},{id: 300}, {ID: 304}, {NO: 405}, {id: 308}, {price:15}],
            'Teacher': [{ level: {good:100, bad:200}, price: 88},{ grade:12}]
        }";
                /*
                json = @"{
                           'course_editions': {
                              '2014SL': [
                                 {
                                    'grades': {
                                       'course_grades': {'name': '12+'}
                                    }
                                 },
                                 {
                                    'grades': {
                                       'course_grades': {}
                                    }
                                 }
                              ]
                           },
                           'Customer': 'VIP',
                           'Score': [101, 203, 304],
                           'Teacher': 'Physics'
                        }";
                        json = @"[
                                    { 'class':{ name: 'en', level:[] }, honor:{} },
                                    { 'class': [10,20] },
                                    { 'Score': [] },
                                    { 'Teacher': {} }
                                ]";
                        */
                #endregion JToken Data

                #region JToken
    JObject jtoken = JObject.Parse(json);
    JArray jts = jtoken.SelectToken("$.Score").Value<JArray>();
Console.WriteLine($"==Select: {jts.GetType()} ===");
foreach(JToken jt in jts)
{
    Console.WriteLine($"----{jt.GetType()}---------");
    Console.WriteLine(jt);
}

                /*
                IList<MYID> jos = jtoken.Value<JToken>("Score").ToObject<IList<MYID>>();
                foreach (MYID jo in jos)
                {
                    Console.WriteLine("el={0}\ntype={1}", JObject.FromObject(jo).ToString(), jo.GetType());
                }
                IEnumerable<JObject> jlist = jtoken.Values<JObject>();
                Console.WriteLine("jlist Type: {0}", jlist.GetType());
                foreach(JObject jel in jlist)
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine(jel);
                }
                */
                /*
                 var jos = jtoken.Value<JToken>("class");
                 foreach (JToken el in jos) {
                     Console.WriteLine("----------------------");
                     Console.WriteLine("Type: {0} el={1}",el.GetType(), el);
                 }

                 YYMM jt1 = jtoken.Value<JToken>("course_editions").Value<JObject>("2015SL").ToObject<YYMM>();
                 Console.WriteLine("JT1 Type: {0}", jt1.GetType());
                 Console.WriteLine(JToken.FromObject(jt1));
                 DateTime teacher = jtoken.Value<JValue>("Teacher").ToObject<DateTime>();
                 Console.WriteLine("Teacher={0}", teacher);

                 IEnumerable<int> scores = jtoken.Value<JArray>("Score").Values<int>("id");
                 Console.WriteLine("Scores: {0}", scores.GetType());
                 foreach (var el in scores)
                 {
                     Console.WriteLine("el={0} type={1}", el, el.GetType());
                 }
                 */

                //Console.WriteLine("Score = {0}", JArray.FromObject(scores).ToString());


                /*
                Console.WriteLine("jtoken type: {0}", jtoken.GetType());
                Console.WriteLine("--------Loop Type ----------");
                foreach (JToken jt1 in jtoken)
                {
                    Console.WriteLine($"--Level 1: {jt1.GetType()}-Value: {jt1.HasValues}------");
                    Console.WriteLine(jt1);
                    foreach (JToken jt2 in jt1)
                    {

                        Console.WriteLine($"----Level 2: {jt2.GetType()}-Value: {jt2.HasValues}------");
                        Console.WriteLine(jt2);
                        foreach (JToken jt3 in jt2)
                        {
                            Console.WriteLine($"------Level 3: {jt3.GetType()}-Value: {jt3.HasValues}----");
                            Console.WriteLine(jt3);

                            foreach (JToken jt4 in jt3)
                            {
                                Console.WriteLine($"--------Level 4: {jt4.GetType()}-Value: {jt4.HasValues}--");
                                Console.WriteLine(jt4);

                                foreach (JToken jt5 in jt4)
                                {
                                    Console.WriteLine($"--------Level 5: {jt5.GetType()}-Value: {jt5.HasValues}--");
                                    Console.WriteLine(jt5);
                                }

                            }

                        }
                    }
                }
                */
                #endregion JToken
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error: {err.Message}\n\nMessage: {err.StackTrace}");
            }

    Console.ReadLine();
        }
    }
}

