package misc

import (
	"syscall"
	"unsafe"
)

var (
	CLSID_MMDeviceEnumerator syscall.GUID = syscall.GUID{
		Data1: 0xBCDE0395,
		Data2: 0xE52F,
		Data3: 0x467C,
		Data4: [8]byte{0x8E, 0x3D, 0xC4, 0x57, 0x92, 0x91, 0x69, 0x2E},
	}

	IID_IMMDeviceEnumerator syscall.GUID = syscall.GUID{
		Data1: 0xA95664D2,
		Data2: 0x9614,
		Data3: 0x4F35,
		Data4: [8]byte{0xA7, 0x46, 0xDE, 0x8D, 0xB6, 0x36, 0x17, 0xE6},
	}

	IID_IAudioEndpointVolume syscall.GUID = syscall.GUID{
		Data1: 0x5CDF2C82,
		Data2: 0x841E,
		Data3: 0x4546,
		Data4: [8]byte{0x97, 0x22, 0x0C, 0xF7, 0x40, 0x78, 0x22, 0x9A},
	}
)

type IMMDeviceEnumeratorVTBL struct {
	QueryInterface                         uintptr
	AddRef                                 uintptr
	Release                                uintptr
	EnumAudioEndpoints                     uintptr
	GetDefaultAudioEndpoint                uintptr
	GetDevice                              uintptr
	RegisterEndpointNotificationCallback   uintptr
	UnregisterEndpointNotificationCallback uintptr
}

type IMMDeviceVTBL struct {
	QueryInterface    uintptr
	AddRef            uintptr
	Release           uintptr
	Activate          uintptr
	OpenPropertyStore uintptr
	GetId             uintptr
	GetState          uintptr
}

type IAudioEndpointVolumeVTBL struct {
	QueryInterface                uintptr
	AddRef                        uintptr
	Release                       uintptr
	RegisterControlChangeNotify   uintptr
	UnregisterControlChangeNotify uintptr
	GetChannelCount               uintptr
	SetMasterVolumeLevel          uintptr
	SetMasterVolumeLevelScalar    uintptr
	GetMasterVolumeLevel          uintptr
	GetMasterVolumeLevelScalar    uintptr
}

type IMMDeviceEnumerator struct {
	Vtbl *IMMDeviceEnumeratorVTBL
}

type IMMDevice struct {
	Vtbl *IMMDeviceVTBL
}

type IAudioEndpointVolume struct {
	Vtbl *IAudioEndpointVolumeVTBL
}

func (v *IMMDeviceEnumerator) Release() {
	syscall.SyscallN(v.Vtbl.Release, uintptr(unsafe.Pointer(v)))
}

func (v *IMMDevice) Release() {
	syscall.SyscallN(v.Vtbl.Release, uintptr(unsafe.Pointer(v)))
}

func (v *IAudioEndpointVolume) Release() {
	syscall.SyscallN(v.Vtbl.Release, uintptr(unsafe.Pointer(v)))
}
