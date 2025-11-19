namespace DrawGheterInfrastructure.Services;

using Amazon.S3;
using Amazon.S3.Model;
using System.Text.Json;

public class SnapshotService(IConfiguration config)
{
    private readonly AmazonS3Client _s3 = new AmazonS3Client(
        config["S3:AccessKey"],
        config["S3:SecretKey"],
        new AmazonS3Config
        {
            ServiceURL = config["S3:Endpoint"],
            ForcePathStyle = true
        });
    private readonly string _bucket = config["S3:Bucket"]!;

    // es: http://minio:9000

    public async Task SaveSnapshotAsync(string matchId, object snapshot)
    {
        var json = JsonSerializer.Serialize(snapshot);

        var request = new PutObjectRequest
        {
            BucketName = _bucket,
            Key = $"snapshots/{matchId}/{DateTime.UtcNow:yyyyMMdd_HHmmss}.json",
            ContentBody = json,
            ContentType = "application/json"
        };

        await _s3.PutObjectAsync(request);
    }

    public async Task<string?> LoadLatestSnapshotAsync(string matchId)
    {
        var list = await _s3.ListObjectsV2Async(new ListObjectsV2Request
        {
            BucketName = _bucket,
            Prefix = $"snapshots/{matchId}/"
        });

        var last = list.S3Objects.OrderByDescending(o => o.LastModified).FirstOrDefault();
        
        if (last == null)
        {
            return null;
        }

        var response = await _s3.GetObjectAsync(_bucket, last.Key);
        using var reader = new StreamReader(response.ResponseStream);

        return await reader.ReadToEndAsync();
    }
}
