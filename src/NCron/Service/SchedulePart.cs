﻿/*
 * Copyright 2010 Joern Schou-Rode
 * 
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

using System;

namespace NCron.Service
{
    public class SchedulePart
    {
        private readonly SchedulingService _service;
        private readonly QueueEntry _queueEntry;

        internal SchedulePart(SchedulingService service, QueueEntry queueEntry)
        {
            _service = service;
            _queueEntry = queueEntry;
        }

        public SchedulePart Run(Func<ICronJob> job)
        {
            _queueEntry.Jobs.Add(job);
            return this;
        }

        public void Named(string name)
        {
            _service.NameEntry(name, _queueEntry);
        }
    }
}
