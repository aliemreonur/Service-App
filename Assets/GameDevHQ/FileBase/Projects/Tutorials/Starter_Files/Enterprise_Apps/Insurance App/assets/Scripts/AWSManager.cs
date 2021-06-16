using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Amazon.Runtime;
using Amazon.CognitoIdentity;
using Amazon;
using UnityEngine.SceneManagement;

public class AWSManager : MonoBehaviour
{
    private static AWSManager _instance;
    public static AWSManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("AWS Manager instance is null");
            }
            return _instance;
        }
    }


    public string S3Region = RegionEndpoint.EUCentral1.SystemName;
    private RegionEndpoint _S3Region
    {
        get
        {
            return RegionEndpoint.GetBySystemName(S3Region);
        }
    }

    private AmazonS3Client _s3Client;
    public AmazonS3Client S3Client
    {
        get
        {
            if(_s3Client == null)
            {
                _s3Client = new AmazonS3Client(new CognitoAWSCredentials
                    ("eu-central-1:81d741ce-0297-4e21-af5c-7c4dc548eabd", RegionEndpoint.EUCentral1), _S3Region);
            }
            return _s3Client; 
        }
    }

    private void Awake()
    {
        _instance = this;

        UnityInitializer.AttachToGameObject(this.gameObject);
        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;

       /* S3Client.ListBucketsAsync(new ListBucketsRequest(), (responseObject) =>
        {
            if (responseObject.Exception == null)
            {
                responseObject.Response.Buckets.ForEach((s3b) =>
                {
                    Debug.Log("Bucket Name : " + s3b.BucketName);

                });
            }
            else
            {
                Debug.Log("AWS Error" + responseObject.Exception);
            }
        }); */
    }

    public void UploadToS3(string path, string caseID)
    {
        FileStream stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

        PostObjectRequest request = new PostObjectRequest()
        {
            Bucket = "serviceappcasefiles11",
            Key = "case#" + caseID,
            InputStream = stream,
            CannedACL = S3CannedACL.Private,
            Region = _S3Region
        };

        S3Client.PostObjectAsync(request, (responseObj) =>
        {
            if (responseObj.Exception == null)
            {
                Debug.Log("Successfully posted to bucket");
                SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("Exception occured during uploading: " + responseObj.Exception);
            }
        });

    }
}
