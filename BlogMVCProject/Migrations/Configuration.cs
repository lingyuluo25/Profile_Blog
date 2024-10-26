namespace BlogMVCProject.Migrations
{
    using BlogMVCProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogMVCProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BlogMVCProject.Models.ApplicationDbContext";
        }

        protected override void Seed(BlogMVCProject.Models.ApplicationDbContext context)
        {
            
            var categories = new List<Category>
            {
                new Category {Name = "Daily Sharing" },
                new Category {Name = "Travel Sharing" },
                new Category {Name = "Design" },
                new Category {Name = "AI" },
                new Category {Name = "Art" },
                new Category {Name = "Coding" },
                new Category {Name = "New Category" }
            };
            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            
            var articles = new List<Article>
            { 
                // Daily Sharing
                new Article {Title = "Morning Habits", Content = "How I start my day with positive habits.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "Daily Sharing").ID},
                new Article {Title = "Evening Reflections", Content = "Reflecting on the day and setting goals for tomorrow.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "Daily Sharing").ID},

                // Travel Sharing 
                new Article {Title = "Exploring Kyoto", Content = "An unforgettable journey through Kyoto's temples and streets.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "Travel Sharing").ID},
                new Article {Title = "Backpacking in Europe", Content = "Tips and stories from my backpacking adventure across Europe.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "Travel Sharing").ID},

                // Design
                new Article {Title = "UI Design Basics", Content = "Essential tips for creating clean and user-friendly interfaces.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "Design").ID},
                new Article {Title = "The Power of Color Theory", Content = "How color impacts design and user experience.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "Design").ID},

                // AI 
                new Article {Title = "AI for Beginners", Content = "A beginner's guide to understanding the basics of artificial intelligence.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "AI").ID},
                new Article {Title = "Future of AI in Healthcare", Content = "Exploring how AI is transforming the healthcare industry.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "AI").ID},

                // Art 
                new Article {Title = "Understanding Modern Art", Content = "Exploring the world of modern art and its influence today.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "Art").ID},
                new Article {Title = "Impressionism Movement", Content = "A look into the impressionist art movement and its pioneers.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "Art").ID},

                // Coding 
                new Article {Title = "Introduction to Python", Content = "Learning Python as a first programming language.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "Coding").ID},
                new Article {Title = "Understanding OOP Concepts", Content = "An overview of object-oriented programming concepts.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "Coding").ID},

                // New Category 
                new Article {Title = "New Category Article 1", Content = "First article for the new category.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "New Category").ID},
                new Article {Title = "New Category Article 2", Content = "Second article for the new category.", PublishedDate = DateTime.Now, CategoryID= context.Categories.Single(c => c.Name == "New Category").ID}
            };

            
            articles.ForEach(a => context.Articles.AddOrUpdate(p => p.Title, a));
            context.SaveChanges();
        }
    }
}
