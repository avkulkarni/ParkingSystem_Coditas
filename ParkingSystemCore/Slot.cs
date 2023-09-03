using ParkingSystemCore.Enums;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystemCore
{
    internal class Slot
    {
        int _freeSpace = 0;
        int _slotLimit = 0;

        public SlotTypeEnum SType { get; }
        public int SlotLimt { get => _slotLimit; }
        public int FreeSpace { get => _freeSpace; }
        public int OccupiedSpace { get => (_slotLimit - _freeSpace); }
        public bool IsSpaceAvailable()
        {
            if (_freeSpace == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal Slot(SlotTypeEnum slotType, int slotLimt)
        {
            if (slotLimt < 0)
                throw new Exception("Zero slot limit not allowed !");

            SType = slotType;
            _slotLimit = slotLimt;
            _freeSpace = slotLimt;
        }

        internal bool Park()
        {
            if (IsSpaceAvailable())
            {
                _freeSpace--;
                return true;
            }
            return false;
        }

        internal bool Remove()
        {
            if(_freeSpace < SlotLimt)
            {
                _freeSpace++;
                return true;
            }
            return false;
        }

    }
}
