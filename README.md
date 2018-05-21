# Zoom NetCore Api

Dotnet Core Package for connecting to [http://correlation.edgate.com/api/docs](EdGate's Api). This repository is a work in progress, and does not yet encompass all the methods available in the EdGate Api.

## Installation

Install from the Nuget repository [https://www.nuget.org/packages/AndcultureCode.EdGate.NetCore.Api/]

## Usage

### Getting your profile details

```
var options = new EdGateClientOptions
{
    EdGatePublicKey  = "Your Api Public Key",
    EdGatePrivateKey = "Your Api Private Key"
};
var client  = new EdGateClient(options);
var profile = client.Profile.GetProfile();
```

## Interfaces

### IEdGateClient

* `IEdGateProfileClient Profile` - Profile Client
* `IEdGateStandardsClient Standards` - Standards Client

### IEdGateProfileClient

* `Profile GetProfile()` - Get profile details for current account. http://correlation.edgate.com/api/docs/profile

    | Parameter     | Description   |
    | ------------- | ------------- |
    | no params     |               |




### IEdGateStandardsClient

* `List<Standard> ExportStandards(string standardsSetId, string subject = "")` - Export list of standards for a given standards set and optionally a subject. [http://api.edgate.com/navigate/#!/Standards/exportStandards](Api Docs)

    | Parameter     | Description   |
    | ------------- | ------------- |
    | standardsSetId |  Id of the parent standards set to filter by |
    | subject |  _(optional)_ Subject that the standards must be associated with |

* `List<StandardsSet> GetStandardsSets()` - Get the list of standards set objects. [http://api.edgate.com/navigate/#!/Standards/findStandardsSets](Api Docs)

    | Parameter     | Description   |
    | ------------- | ------------- |
    | no params     |               |

* `List<Standard> GetStandardsBySet(string standardsSetId, string subject, string grade, bool correlate)` - Get list of standards for a given standards set. [http://api.edgate.com/navigate/#!/Standards/findStandardList](Api Docs)

    | Parameter     | Description   |
    | ------------- | ------------- |
    | standardsSetId |  Id of the parent standards set to filter by |
    | subject |  Subject that the standards must be associated with |
    | grade |  Grade that the standards must be associated with |

* `Standard GetStandard(string standardId)` - Get data for an individual standard. [http://api.edgate.com/navigate/#!/Standards/findStandardById](Api Docs)

    | Parameter     | Description   |
    | ------------- | ------------- |
    | standardsSetId |  Id of the parent standards set to filter by |
    | subject |  Subject that the standards must be associated with |
    | grade |  Grade that the standards must be associated with |