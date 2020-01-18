//
//  SwiftForUnity.swift
//  SwiftPlugin
//
//  Created by Alice Liang on 1/18/20.
//  Copyright © 2020 Alice Liang. All rights reserved.
//

import Foundation
import Foundation
import UIKit
@objc public class SwiftForUnity: UIViewController {
    @objc static let shared = SwiftForUnity()
    @objc func SayHiToUnity() -> String{
        return "Hi, I'm Swift"
    }
}
