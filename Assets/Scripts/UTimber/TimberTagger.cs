/*
 *    Copyright 2025 UDF Owner
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 *    More details: https://udfsoft.com/
 */

using System;

public class TimberTagger
{
    public void V(string message) => Timber.V(message);
    public void D(string message) => Timber.D(message);
    public void I(string message) => Timber.I(message);
    public void W(string message) => Timber.W(message);
    public void E(string message) => Timber.E(message);
    public void E(Exception ex) => Timber.E(ex);
    public void E(string message, Exception ex) => Timber.E(message, ex);
}