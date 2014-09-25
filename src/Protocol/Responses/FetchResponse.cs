﻿using System.Linq;

namespace kafka4net.Protocol.Responses
{
    class FetchResponse
    {
        public TopicFetchData[] Topics;

        public class TopicFetchData
        {
            public string Topic;
            public PartitionFetchData[] Partitions;

            public override string ToString()
            {
                return string.Format("Topic: {0} parts: [{1}]", Topic, string.Join(",", Partitions.AsEnumerable()));
            }
        }

        public class PartitionFetchData
        {
            public int Partition;
            public ErrorCode ErrorCode;
            public long HighWatermarkOffset;
            public Message[] Messages;

            public override string ToString()
            {
                return string.Format("Part: {0}, Err: {1}, HighOffs: {2}, Messages: {3}", Partition, ErrorCode, HighWatermarkOffset, Messages.Length);
            }
        }

        public override string ToString()
        {
            return string.Format("[{0}]", string.Join(",", Topics.AsEnumerable()));
        }
    }
}
