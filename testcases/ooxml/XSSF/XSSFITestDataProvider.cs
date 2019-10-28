/* ====================================================================
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for Additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
==================================================================== */

namespace NPOI.XSSF
{

    using TestCases.SS;
    using NPOI.XSSF.UserModel;
    using System;
    using NPOI.SS;
    using NPOI.SS.UserModel;
    using TestCases;

    /**
     * @author Yegor Kozlov
     */
    public class XSSFITestDataProvider : ITestDataProvider
    {
        public static XSSFITestDataProvider instance = new XSSFITestDataProvider();

        private XSSFITestDataProvider()
        {
            // enforce Singleton
        }
        public IWorkbook OpenSampleWorkbook(String sampleFileName)
        {
            return XSSFTestDataSamples.OpenSampleWorkbook(sampleFileName);
        }
        public IWorkbook WriteOutAndReadBack(IWorkbook original)
        {
            if (!(original is XSSFWorkbook))
            {
                throw new ArgumentException("Expected an instance of XSSFWorkbook, but had " + original.GetType().Name);
            }
            return XSSFTestDataSamples.WriteOutAndReadBack((XSSFWorkbook)original);
        }

        public IWorkbook CreateWorkbook()
        {
            return new XSSFWorkbook();
        }

        //************ SXSSF-specific methods ***************//
        /**
         * Provides way of creating a SXSSFWorkbook with a specific row access window size.
         * Equivalent to createWorkbook on others.
         * @return an instance of Workbook
         */
        public IWorkbook CreateWorkbook(int rowAccessWindowSize)
        {
            return CreateWorkbook();
        }
        
        public void TrackAllColumnsForAutosizing(ISheet sheet) { }
        //************ End SXSSF-specific methods ***************//
        public void TrackColumnsForAutosizing(ISheet sheet, params int[] columns) { }

        public IFormulaEvaluator CreateFormulaEvaluator(IWorkbook wb)
        {
            return new XSSFFormulaEvaluator((XSSFWorkbook)wb);
        }

        public byte[] GetTestDataFileContent(String fileName)
        {
            return POIDataSamples.GetSpreadSheetInstance().ReadFile(fileName);
        }
        public SpreadsheetVersion GetSpreadsheetVersion()
        {
            return SpreadsheetVersion.EXCEL2007;
        }
        public String StandardFileNameExtension
        {
            get
            {
                return "xlsx";
            }
        }

        
    }
}



