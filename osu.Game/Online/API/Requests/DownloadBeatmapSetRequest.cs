﻿using osu.Game.Beatmaps;
using System;

namespace osu.Game.Online.API.Requests
{
    public class DownloadBeatmapSetRequest : APIDownloadRequest
    {
        private readonly BeatmapSetInfo beatmapSet;

        public Action<float> DownloadProgressed;

        public DownloadBeatmapSetRequest(BeatmapSetInfo beatmapSet)
        {
            this.beatmapSet = beatmapSet;

            Progress += (current, total) => DownloadProgressed?.Invoke((float) current / total);
        }

        protected override string Target => $@"beatmapsets/{beatmapSet.OnlineBeatmapSetID}/download";
    }
}
