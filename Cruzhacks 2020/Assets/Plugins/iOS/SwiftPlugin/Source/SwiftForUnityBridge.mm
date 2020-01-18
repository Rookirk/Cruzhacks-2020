//
//  SwiftForUnityBridge.m
//  SwiftPlugin
//
//  Created by Alice Liang on 1/18/20.
//  Copyright © 2020 Alice Liang. All rights reserved.
//

#import <Foundation/Foundation.h>
#include "SwiftPlugin-Swift.h"
#pragma mark - C interface
extern "C" {
    char* _sayHiToUnity() {
        NSString *returnString = [[SwiftForUnity shared]       SayHiToUnity];
        char* cStringCopy(const char* string);
        return cStringCopy([returnString UTF8String]);
    }
}
char* cStringCopy(const char* string){
    if (string == NULL){
        return NULL;
    }
    char* res = (char*)malloc(strlen(string)+1);
    strcpy(res, string);
    return res;
}
