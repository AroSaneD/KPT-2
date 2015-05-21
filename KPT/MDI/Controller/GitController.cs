using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using Client.Properties;
using System.Web.Script.Serialization;
using GitSharp.Commands;

namespace Client
{
    public class GitBranch
	{
		public string name { get; set; }
		public string sha { get; set; }
		public string url { get; set; }
	}

	class GitBlob
	{
		public string sha { get; set; }
		public int size { get; set; }
		public string url { get; set; }
		public string content { get; set; }
		public string encoding { get; set; }
	}

	[Serializable]
	class GitNewCommit
	{
		public GitNewCommit()
		{
			parents = new List<string>();
		}
		public string message { get; set; }
		public GitCommitCommitAuthor author { get; set; }
		public List<string> parents { get; set; }
		public string tree { get; set; }
	}

    public class GitCommit
	{
		public GitCommit()
		{
			commit = new GitCommitCommit();
			author = new GitCommitAuthor();
		}
		public string sha { get; set; }
		public string url { get; set; }
		public string html_url { get; set; }
		public GitCommitCommit commit { get; set; }
		public GitCommitAuthor author { get; set; }
	}

	class GitCommitFile
	{
		public string sha { get; set; }
		public string filename { get; set; }
		public string status { get; set; }

	}

    public class GitCommitCommit
	{
		public GitCommitCommitAuthor author { get; set; }
		public string message { get; set; }
		public GitCommitTree tree { get; set; }
		public string url { get; set; }
	}

    public class GitCommitAuthor
	{
		public string login { get; set; }
		public string avatar_url { get; set; }
	}

    public class GitCommitCommitAuthor
	{
		public string name { get; set; }
		public string email { get; set; }
		public string date { get; set; }
	}

    public class GitCommitTree
	{
		public string sha { get; set; }
		public string url { get; set; }
	}

	class GitTree
	{
		public GitTree()
		{
			tree = new List<GitTreeTree>();
		}
		public string sha { get; set; }
		public string url { get; set; }
		public List<GitTreeTree> tree { get; set; }
	}
	[Serializable]
	class GitNewTree
	{
		public GitNewTree()
		{
			tree = new List<GitNewTreeTree>();
		}
		public string base_tree { get; set; }
		public List<GitNewTreeTree> tree { get; set; }
	}

	[Serializable]
	class GitNewTreeTree
	{
		public string path { get; set; }
		public string mode { get; set; }
		public string type { get; set; }
		public string sha { get; set; }
	}

	class GitTreeTree
	{
		public string path { get; set; }
		public string mode { get; set; }
		public string type { get; set; }
		public string sha { get; set; }
		public int size { get; set; }
		public string url { get; set; }
	}

	[Serializable]
	class GitRef
	{
		public string Ref { get; set; }
		public string url { get; set; }
		public GitRefObject Object { get; set; }
	}

	[Serializable]
	class GitRefObject
	{
		public string sha { get; set; }
		public string type { get; set; }
		public string url { get; set; }
	}

	public class GitController
	{
		private HttpWebResponse GetHttpWebResponse(HttpWebRequest request)
		{
			HttpWebResponse response = null;

			try
			{
				request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.1.4322)";

				request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("MSiliunas" + ":" + "m4kaliuze"));

				response = (HttpWebResponse)request.GetResponse();
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
			}

			return response;
		}

		public List<GitBranch> GetRepositoryBranches(string org, string repo)
		{
			var branches = new List<GitBranch>();
			try
			{
				var jss = new JavaScriptSerializer();

				var repoUrl = Resources.GitApiUrl + Resources.GitRepos + "/" + org + "/" + repo + Resources.GitBranches;

				var request = (HttpWebRequest) WebRequest.Create(repoUrl);

				var responseString = new StreamReader(GetHttpWebResponse(request).GetResponseStream()).ReadToEnd();

				branches = (jss.Deserialize<GitBranch[]>(responseString)).ToList();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return branches;
		}

		public GitCommit GetCommit(string org, string repo, string sha)
		{
			var commit = new GitCommit();

			try
			{
				var jss = new JavaScriptSerializer();

				var url = Resources.GitApiUrl + Resources.GitRepos + "/" + org + "/" + repo + Resources.GitCommits + "/" + sha;

				var request = (HttpWebRequest)WebRequest.Create(url);

				var responseString = new StreamReader(GetHttpWebResponse(request).GetResponseStream()).ReadToEnd();

				commit = jss.Deserialize<GitCommit>(responseString);
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
			}

			return commit;
		}

		/**
		 * org - repo author name
		 * repo - repository name
		 * username - github login
		 * password - github password
		 * filepath - path to the file which you want to commit
		 * branch - git branch name (will be commited to the head)
		 */
		public string CommitFile(string org, string repo, string username, string password, string filepath, string branch, string commitMessage)
		{
			var jss = new JavaScriptSerializer();
			string url;
			HttpWebRequest request;

			try
			{
				var newFile = Convert.ToBase64String(File.ReadAllBytes(filepath));

				url = Resources.GitApiUrl + Resources.GitRepos + "/" + org + "/" + repo + Resources.GitGit + Resources.GitReferences +
						   Resources.GitHeads + "/" + branch;

				request = (HttpWebRequest)WebRequest.Create(url);
				var responseString = "";
				using (var response = GetHttpWebResponse(request))
				{
					responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
				}

				var headRef = jss.Deserialize<GitRef>(responseString);

				var headCommit = GetCommit(org, repo, headRef.Object.sha);

				url = headCommit.commit.tree.url;

				request = (HttpWebRequest)WebRequest.Create(url);

				using (var response = GetHttpWebResponse(request))
				{
					responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
				}

				var headTree = jss.Deserialize<GitTree>(responseString);

				var oldFileUrl = headTree.tree.Single(file => file.path == filepath).url;

				var json = new JavaScriptSerializer().Serialize(new
				{
					content = newFile,
					encoding = "base64"
				});

				url = Resources.GitApiUrl + Resources.GitRepos + "/" + org + "/" + repo + Resources.GitGit + Resources.GitBlobs;
				 var requestPost = (HttpWebRequest)WebRequest.Create(url);

				requestPost.Method = "POST";

				var newBlob = new GitBlob();
				using (var streamWriter = new StreamWriter(requestPost.GetRequestStream()))
				{
					streamWriter.Write(json);
					streamWriter.Flush();
					streamWriter.Close();

					var httpResponse = GetHttpWebResponse(requestPost);
					using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
					{
						var result = streamReader.ReadToEnd();
						newBlob = jss.Deserialize<GitBlob>(result);
					}
				}

				var newTree = new GitNewTree {base_tree = headCommit.commit.tree.sha};
				newTree.tree.Add(new GitNewTreeTree() {mode = "100644", path = filepath, sha = newBlob.sha, type = "blob"});

				json = new JavaScriptSerializer().Serialize(newTree);

				url = Resources.GitApiUrl + Resources.GitRepos + "/" + org + "/" + repo + Resources.GitGit + Resources.GitTrees;
				var requestPostTree = (HttpWebRequest)WebRequest.Create(url);

				requestPostTree.Method = "POST";

				var newCreatedTree = new GitTree();
				using (var streamWriter = new StreamWriter(requestPostTree.GetRequestStream()))
				{
					streamWriter.Write(json);
					streamWriter.Flush();
					streamWriter.Close();

					var httpResponse = GetHttpWebResponse(requestPostTree);
					using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
					{
						var result = streamReader.ReadToEnd();
						newCreatedTree = jss.Deserialize<GitTree>(result);
					}
				}

				var newCommit = new GitNewCommit();
				newCommit.message = "Test Msg";
				newCommit.author = new GitCommitCommitAuthor() { date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK"), email = "Email@mail.ru", name = "MSiliunas" };
				newCommit.parents.Add(headCommit.sha);
				newCommit.tree = newCreatedTree.sha;

				json = new JavaScriptSerializer().Serialize(newCommit);

				url = Resources.GitApiUrl + Resources.GitRepos + "/" + org + "/" + repo + Resources.GitGit + Resources.GitCommits;
				var requestPostCommit = (HttpWebRequest)WebRequest.Create(url);

				requestPostCommit.Method = "POST";
				requestPostCommit.ContentType = "application/json";

				var newCreatedCommit = new GitCommit();
				using (var streamWriter = new StreamWriter(requestPostCommit.GetRequestStream()))
				{
					streamWriter.Write(json);
					streamWriter.Flush();
					streamWriter.Close();

					var httpResponse = GetHttpWebResponse(requestPostCommit);
					using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
					{
						var result = streamReader.ReadToEnd();
						newCreatedCommit = jss.Deserialize<GitCommit>(result);
					}
				}

				url = Resources.GitApiUrl + Resources.GitRepos + "/" + org + "/" + repo + Resources.GitGit + Resources.GitReferences +
						   Resources.GitHeads + "/" + branch;

				var requestPostRef = (HttpWebRequest)WebRequest.Create(url);

				requestPostRef.Method = "PATCH";
				requestPostRef.ContentType = "application/json";

				json = new JavaScriptSerializer().Serialize(new
				{
					sha = newCreatedCommit.sha,
					force = true
				});

				using (var streamWriter = new StreamWriter(requestPostRef.GetRequestStream()))
				{
					streamWriter.Write(json);
					streamWriter.Flush();
					streamWriter.Close();

					var httpResponse = GetHttpWebResponse(requestPostRef);
					using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
					{
						var result = streamReader.ReadToEnd();
						return result;
					}
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}
			return "";
		}
	}
}
