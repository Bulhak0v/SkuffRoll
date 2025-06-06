package com.example.skuffrollmobileclient.data.model
import com.google.gson.annotations.SerializedName

data class CharacterDto(
    @SerializedName("id")
    val id: Int,

    @SerializedName("user_id")
    val userId: Int?,

    @SerializedName("name")
    val name: String,

    @SerializedName("appearance")
    val appearance: String?,

    @SerializedName("alignment")
    val alignment: String?,

    @SerializedName("gender")
    val gender: String?,

    @SerializedName("age")
    val age: Int?,

    @SerializedName("weight")
    val weight: Double?,

    @SerializedName("height")
    val height: Double?,

    @SerializedName("flaws")
    val flaws: String?,

    @SerializedName("bonds")
    val bonds: String?,

    @SerializedName("ideals")
    val ideals: String?,

    @SerializedName("personality_traits")
    val personalityTraits: String?,

    @SerializedName("backstory")
    val backstory: String?,

    @SerializedName("hp")
    val hp: Int?,

    @SerializedName("level")
    val level: Int,

    @SerializedName("class_id")
    val classId: Int?,

    @SerializedName("race_id")
    val raceId: Int?,

    @SerializedName("subrace_id")
    val subraceId: Int?,

    @SerializedName("background_id")
    val backgroundId: Int?,

    @SerializedName("speed")
    val speed: Int?,

    @SerializedName("armor_class")
    val armorClass: Int?,

    @SerializedName("image")
    val image: String?,

    @SerializedName("armor_proficiency")
    val armorProficiency: String?,

    @SerializedName("weapon_proficiency")
    val weaponProficiency: String?,

    @SerializedName("vehicle_proficiency")
    val vehicleProficiency: String?,

    @SerializedName("tool_proficiency")
    val toolProficiency: String?
)
