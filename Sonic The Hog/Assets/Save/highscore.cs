using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;
public partial class highscore : IRealmObject
{
    [MapTo("_id")]
    [PrimaryKey]
    public ObjectId? Id { get; set; }
    [MapTo("insertedAt")]
    public DateTimeOffset? InsertedAt { get; set; }
    [MapTo("partition")]
    public string? Partition { get; set; }
    [MapTo("player")]
    public string? Player { get; set; }
    [MapTo("score")]
    public int? Score { get; set; }
}
