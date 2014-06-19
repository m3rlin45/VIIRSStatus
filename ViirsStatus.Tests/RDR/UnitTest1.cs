using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RDR;

namespace ViirsStatus.Tests.RDR
{
    [TestClass]
    public class RdrStaticHeaderTest
    {
        string getTestSatellite()
        {
            return "foo";
        }
        string getTestSensor()
        {
            return "Foobar";
        }
        string getTestTypeId()
        {
            return "baz buz foo";
        }
        UInt32 getTestNumApids()
        {
            return 2566848;
        }
        UInt32 getTestApidListOffset()
        {
            return 212083240;
        }
        UInt32 getTestPktTrackerOffset()
        {
            return 209873402;
        }
        UInt32 getTestApStorageOffset()
        {
            return 308435098;
        }
        UInt32 getTestNextPacketPos()
        {
            return 98450038;
        }
        Int64 getTestStartBoundary()
        {
            return 028304802708023;
        }
        Int64 getTestEndBoundary()
        {
            return 08304598038030904;
        }
        IEnumerable<Byte> getTestVector()
        {
            return new Byte[] {
                0x66, 0x6f, 0x6f, 0x00, //satellite "foo"
                0x46, 0x6f, 0x6f, 0x62, 0x61, 0x72, 0x00, 0x00, //first half of sensor "Foobar"
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, //second half of sensor
                0x62, 0x61, 0x7a, 0x20, 0x62, 0x75, 0x7a, 0x20, //first half of typeId "baz buz foo"
                0x66, 0x6f, 0x6f, 0x00, 0x00, 0x00, 0x00, 0x00, // second half of typeId
                0x00, 0x27, 0x2A, 0xC0, //numApids 2566848
                0x0C, 0xA4, 0x22, 0x28, //ApidListOffset 212083240
                0x0C, 0x82, 0x69, 0xFA, //PktTrackerOffset 209873402
                0x12, 0x62, 0x58, 0x9A, //ApStorageOffset 308435098
                0x05, 0xDE, 0x3A, 0x76, //NextPacketPos 98450038
                0x00, 0x00, 0x19, 0xBE, 0x39, 0xB5, 0xFA, 0x37, //StartBoundary 028304802708023
                0x00, 0x1D, 0x80, 0xFC, 0xE8, 0x0F, 0x2A, 0x38, //EndBoundary 08304598038030904            
            };
        }

        private RdrStaticHeader EnumerableConstructed;

        [TestInitialize]
        public void SetupConstructedInstances()
        {
            EnumerableConstructed = new RdrStaticHeader(getTestVector());
        }

        [TestMethod]
        public void EnumerableConstructor_Satellite_Parses_Correctly()
        {
            Assert.AreEqual<string>(getTestSatellite(), EnumerableConstructed.Satellite);
        }
        [TestMethod]
        public void EnumerableConstructor_Sensor_Parses_Correctly()
        {
            Assert.AreEqual<string>(getTestSensor(), EnumerableConstructed.Sensor);
        }
        [TestMethod]
        public void EnumerableConstructor_TypeId_Parses_Correctly()
        {
            Assert.AreEqual<string>(getTestTypeId(), EnumerableConstructed.TypeId);
        }
        [TestMethod]
        public void EnumerableConstructor_NumApids_Parses_Correctly()
        {
            Assert.AreEqual<UInt32>(getTestNumApids(), EnumerableConstructed.NumApids);
        }
    }
}
