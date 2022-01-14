using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.ViewModels;
using WhatColor.Models;
using WhatColor.Controllers;
using Microsoft.AspNetCore.Authorization;
using WhatColor.Data;
using Microsoft.EntityFrameworkCore;

namespace WhatColor.Controllers
{
    public class WhatColorController : Controller
    {
        private readonly WhatColorContext _context;
        public WhatColorController(WhatColorContext context)
        {
            _context = context;

            //Hardcoded zaken om wat entries te hebben zoals categories, deze veranderen niet

            //Als de colorcategorielijst leeg is -> vul deze
            if (_context.ColorCategories.ToList().Count == 0)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(new ColorCategory()
                    {
                        MainColor = "Red",
                        Meaning = "The color of passion and energy. Red draws attention like no other color and radiates a strong and powerful energy that motivates us to take action. It is also linked to sexuality and stimulates deep and intimate passion. Red is ubiquitously used to warn and signal caution and danger.",
                        Negative = "Anger, Danger, Revenge, Aggression",
                        Positive = "Sexuality, Courage, Desire, Confidence"
                    });
                    _context.Add(new ColorCategory()
                    {
                        MainColor = "Orange",
                        Meaning = "The color of enthusiasm and emotion. Orange exudes warmth and joy and is considered a fun color that provides emotional strength. It is optimistic and upliftning, adds spontaneity and positivity to life and it encourages social communication and creativity. It is a youthful and energetic color.",
                        Negative = "Exhibitionism, Superficial, Impatient, Domination",
                        Positive = "Sexuality, Courage, Desire, Confidence"
                    });
                    _context.Add(new ColorCategory()
                    {
                        MainColor = "Yellow",
                        Meaning = "The color of happiness and optimism. Yellow is a cheerful and energetic color that brings fun and joy to the world. It makes learning easier as it affects the logical part of the brain, stimulating mentality and perception. It inspires thought and curiosity and boosts enthusiasm and confidence.",
                        Negative = "Cowardice, Deception, Egotism, Caution",
                        Positive = "Creativity, Perception, Mentality, Warmth"
                    });
                    _context.Add(new ColorCategory()
                    {
                        MainColor = "Green",
                        Meaning = "The color of harmony and health. Green is a generous, relaxing color that revitalizes our body and mind. It balances our emotions and leaves us feeling safe and secure. It also gives us hope, with promises of growth and prosperity, and it provides a little bit of luck to help us along the way.",
                        Negative = "Judgmental, Envy, Materialism, Inexperience",
                        Positive = "Generosity, Hope, Prosperity, Luck"
                    });
                    _context.Add(new ColorCategory()
                    {
                        MainColor = "Turquoise",
                        Meaning = "The color of calmness and clarity. Turquoise stabilizes emotions and increases empathy and compassion. It emits a cool calming peace, gives us a boost of positive mental energy that improves concentration and clarifies our mind, and creates a balance that clears the path to spiritual growth.",
                        Negative = "Narcissism, Stress, Secrecy, Boastfulness",
                        Positive = "Concentrate, Growth, Peace, Empathy"
                    });
                    _context.Add(new ColorCategory()
                    {
                        MainColor = "Blue",
                        Meaning = "The color of trust and loyalty. Blue has a calming and relaxing effect on our psyche, that gives us peace and makes us feel confident and secure. It dislikes confrontation and too much attention, but it is an honest, reliable and responsible color and you can always count on its support.",
                        Negative = "Conservative, Passive, Depressed, Predictable",
                        Positive = "Confidence, Peace, Honesty, Reliability"
                    });
                    _context.Add(new ColorCategory()
                    {
                        MainColor = "Purple",
                        Meaning = "The color of spirituality and imagination. Purple inspires us to divulge our innermost thoughts, which enlightens us with wisdom of who we are and encourages spiritual growth. It is often associated with royalty and luxury, and its mystery and magic sparks creative fantasies.",
                        Negative = "Sensitive, Vigilant, Immature, Emotional",
                        Positive = "Compassion, Fantasy, Wisdom, Creativity"
                    });
                    _context.Add(new ColorCategory()
                    {
                        MainColor = "Pink",
                        Meaning = "The color of love and compassion. Pink is kind and comforting, full of sympathy and compassion, and makes us feel accepted. Its friendly, playful spirit calms and nurtures us, bringing joy and warmth into our lives. Pink is also a feminine and intuitive color that is bursting with pure romance.",
                        Negative = "Emotional, Timid, Immature, Unconfident",
                        Positive = "Kindness, Warmth, Romance, Intuition"
                    });
                    _context.Add(new ColorCategory()
                    {
                        MainColor = "Brown",
                        Meaning = "The color of stability and reliability. Brown is dependable and comforting. A great counselor and friend full of wisdom. You can count on its help if you need an honest opinion, support and protection. It stabilizes us, helps us stay grounded and inspires us to appreciate the simple things in life.",
                        Negative = "Boring, Dull, Timid, Predictable",
                        Positive = "Appreciation, Support, Wisdom, Dependable"
                    });
                    _context.Add(new ColorCategory()
                    {
                        MainColor = "Black",
                        Meaning = "The color of power and sophistication. Black is an incredibly strong and intimidating color that exudes authority and makes us feel secure and protected. Often seen at formal and prestigious events, this mysterious marvel arouses and seduces our senses with its elegance and sexiness.",
                        Negative = "Depression, Sadness, Pessimism, Dominance",
                        Positive = "Formality, Strength, Prestige, Authority"
                    });
                    _context.Add(new ColorCategory()
                    {
                        MainColor = "Gray",
                        Meaning = "The color of compromise and control. Gray is neutral, conservative and unemotional. It is practically solid as a rock, making it incredibly stable, reliable and calming. It has a peaceful, relaxing and soothing presence. Gray avoids attention but offers mature, insightful advice to anyone who asks.",
                        Negative = "Pessimistic, Sad, Indecisive, Unemotional",
                        Positive = "Reliability, Maturity, Intellect, Conservative"
                    });
                    _context.Add(new ColorCategory()
                    {
                        MainColor = "White",
                        Meaning = "The color of purity and innocence. White is a true balance of all colors and is associated with cleanliness, simplicity and perfection. It loves to make others feel good and provides hope and clarity by refreshing and purifying the mind. It also promotes open-mindedness and self-reflection.",
                        Negative = "Boring, Cold, Empty, Distant",
                        Positive = "Goodness, Hope, Clarity, Openness"
                    });
                    _context.SaveChangesAsync();
                }
            }

        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            WhatColorViewModel viewModel = new WhatColorViewModel();
            viewModel.Colors = _context.Colors.ToList();

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Search(WhatColorViewModel viewModel)
        {

            if (!string.IsNullOrEmpty(viewModel.ColorSearch))
            {
                viewModel.Colors = await _context.Colors.Where(b => b.HEX.Contains(viewModel.ColorSearch)).ToListAsync();
            }
            else
            {
                viewModel.Colors = await _context.Colors.ToListAsync();
            }
            return View("Color", viewModel);

        }
    }
}