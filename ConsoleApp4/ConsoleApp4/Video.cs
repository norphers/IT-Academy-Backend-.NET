using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace ConsoleApp4
{
    public class Video
    {
        public enum State
        {
            Play, Pause, Stop
        }
        private string username;
        private string url;
        private string title;
        private List<Tag> tags = new List<Tag>();
        private State state;

        public Video()
        {
            state = State.Stop;
        }
        public Video(string username, string url, string title)
        {
            this.username = username;
            this.url = url;
            this.title = title;
        }
        public Video(List<Tag> tags)
        {
            this.tags = tags;
        }
        public string GetUrl()
        {
            return this.url;
        }
        public void SetUrl(string url)
        {
            this.url = url;
        }
        public string GetTitle()
        {
            return this.title;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public State GetState()
        {
            return this.state;
        }
        public void SetState(State state)
        {
            this.state = state;
        }
        public string GetUsername()
        {
            return username;
        }
        public void SetUsername(string username)
        {
            this.username = username;
        }
        public override string ToString()
        {
            return "\ntitle: " + title.ToString() + ".\nurl: " + url.ToString() + "\ntags: " + tags.ToString() + "\n";
        }
    }

    public class Tag
    {
        private string _newTag;
        public string NewTag { get => _newTag; set { if ((value != "") && (value == null)) { _newTag = value; } } }  
    }
}
