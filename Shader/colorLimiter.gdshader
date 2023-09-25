shader_type canvas_item;
uniform vec4 color_3 = vec4(31, 51, 64, 1.0);
uniform vec4 color_4 = vec4(69, 97, 109, 1.0);
uniform vec4 color_5 = vec4(121, 134, 138, 1.0);
uniform vec4 color_6 = vec4(185, 186, 180, 1.0);
uniform vec4 color_7 = vec4(225, 221, 212, 1.0);
uniform vec4 color_8 = vec4(245, 241, 230, 1.0);
uniform vec4 color_9 = vec4(251, 249, 245, 1.0);
uniform vec4 color_10 = vec4(0, 39, 65, 1.0);
uniform vec4 color_11 = vec4(0, 63, 80, 1.0);
uniform vec4 color_12 = vec4(0, 94, 98, 1.0);
uniform vec4 color_13 = vec4(0, 130, 110, 1.0);
uniform vec4 color_14 = vec4(0, 166, 114, 1.0);
uniform vec4 color_15 = vec4(106, 186, 107, 1.0);
uniform vec4 color_16 = vec4(181, 213, 161, 1.0);
uniform vec4 color_17 = vec4(232, 230, 208, 1.0);
uniform vec4 color_18 = vec4(12, 56, 88, 1.0);
uniform vec4 color_19 = vec4(30, 84, 127, 1.0);
uniform vec4 color_20 = vec4(26, 114, 173, 1.0);
uniform vec4 color_21 = vec4(19, 145, 204, 1.0);
uniform vec4 color_22 = vec4(58, 175, 233, 1.0);
uniform vec4 color_23 = vec4(145, 213, 245, 1.0);
uniform vec4 color_24 = vec4(213, 235, 238, 1.0);
uniform vec4 color_25 = vec4(54, 49, 89, 1.0);
uniform vec4 color_26 = vec4(94, 70, 116, 1.0);
uniform vec4 color_27 = vec4(141, 84, 147, 1.0);
uniform vec4 color_28 = vec4(189, 102, 168, 1.0);
uniform vec4 color_29 = vec4(228, 128, 188, 1.0);
uniform vec4 color_30 = vec4(246, 179, 213, 1.0);
uniform vec4 color_31 = vec4(66, 49, 68, 1.0);
uniform vec4 color_32 = vec4(110, 62, 77, 1.0);
uniform vec4 color_33 = vec4(163, 77, 90, 1.0);
uniform vec4 color_34 = vec4(211, 93, 103, 1.0);
uniform vec4 color_35 = vec4(237, 126, 130, 1.0);
uniform vec4 color_36 = vec4(254, 181, 178, 1.0);
uniform vec4 color_37 = vec4(245, 220, 219, 1.0);
uniform vec4 color_38 = vec4(26, 16, 19, 1.0);
uniform vec4 color_39 = vec4(47, 29, 30, 1.0);
uniform vec4 color_40 = vec4(73, 48, 43, 1.0);
uniform vec4 color_41 = vec4(111, 64, 51, 1.0);
uniform vec4 color_42 = vec4(157, 90, 60, 1.0);
uniform vec4 color_43 = vec4(206, 121, 68, 1.0);
uniform vec4 color_44 = vec4(228, 153, 79, 1.0);
uniform vec4 color_45 = vec4(250, 198, 129, 1.0);
uniform vec4 color_46 = vec4(252, 226, 186, 1.0);
uniform sampler2D SCREEN_TEXTURE : hint_screen_texture, filter_nearest;
void fragment() {

	vec4 colors[44] = {color_3,color_4,color_5,color_6,color_7,color_8,color_9,color_10,color_11,color_12,color_13,color_14,color_15,color_16,color_17,color_18,color_19,color_20,color_21,color_22,color_23,color_24,color_25,color_26,color_27,color_28,color_29,color_30,color_31,color_32,color_33,color_34,color_35,color_36,color_37,color_38,color_39,color_40,color_41,color_42,color_43,color_44,color_45,color_46};
	float min_diff = -1.0;
	vec4 min_color = vec4(0.0, 0.0, 0.0, 1.0);

	vec2 uv = SCREEN_UV;

	vec4 temp = textureLod(SCREEN_TEXTURE, uv, 0.0);
	vec4 fromRGB = vec4(255,255,255,1);
	min_diff = 1000.0;
	for (int i = 0; i < colors.length(); i++) {

		float curr_dist = distance(colors[i]/fromRGB, temp);
		if (curr_dist < min_diff) {
			min_diff = curr_dist;
			min_color = colors[i]/fromRGB;
		}
		
	}
	COLOR.rgb = min_color.rgb;
}